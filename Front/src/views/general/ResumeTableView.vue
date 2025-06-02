<template>
    <Pane
        content-padding
        content-grow
    >
        <TablePageLayout>
            <template #title> Resume Table </template>

            <template #default></template>
        </TablePageLayout>
    </Pane>
</template>

<script lang="ts">
import { defineComponent } from 'vue'
import Pane from 'components/shared/PaneLayout.vue'
import TablePageLayout from 'components/shared/TablePageLayout.vue'

interface Data {
    /** Page title */
    pageTitle: string
}

// Todo: implement content for the table layout
export default defineComponent({
    components: {
        Pane,
        TablePageLayout,
    },

    data(): Data {
        return {
            pageTitle: 'Resume Table',
        }
    },
})
</script>
