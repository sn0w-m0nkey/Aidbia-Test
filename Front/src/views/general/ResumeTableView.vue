<template>
    <Pane
        content-padding
        content-grow
    >
        <TablePageLayout>
            <template #title> Resume Table </template>

            <template #default :resumes='resumes'>
                <ResumeTable :resumes='resumes'>
`
                </ResumeTable>
            </template>

        </TablePageLayout>
    </Pane>
</template>

<script lang="ts">
import { defineComponent } from 'vue'
import Pane from 'components/shared/PaneLayout.vue'
import TablePageLayout from 'components/shared/TablePageLayout.vue'
import ResumeTable from 'views/general/ResumeTable.vue'

import { onMounted } from 'vue'
import { resumes } from '~@/views/general/data/resumes'

interface Data {
    /** Page title */
    pageTitle: string
}

// Todo: implement content for the table layout
export default defineComponent({
    components: {
        Pane,
        TablePageLayout,
        ResumeTable,
    },

    data(): Data {
        return {
            pageTitle: 'Resume Table',
            resumes: resumes
        }
    },
    setup() {
        onMounted(() => {
            console.log('resumes', resumes)
        })
    },
})
</script>
